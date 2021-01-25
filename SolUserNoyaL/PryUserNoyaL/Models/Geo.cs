using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PryUserNoyaL.Models
{
    public class Geo
    {
        [Key]
        [Required]
        public string lat { get; set; }
        [Required]
        public string lng { get; set; }
    }
}