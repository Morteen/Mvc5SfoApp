using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfoApp.Models
{
    public class Ansatt
    {
        public int AnsattId { get; set; }
        [Required]
        public string Fornavn { get; set; }
        [Required]
        public string Etternavn { get; set; }

        public int SkoleId { get; set; }
        public Skole Skole { get; set; }
    }
}