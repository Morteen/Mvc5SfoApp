using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfoApp.Models
{
    public class Elev
    {
        public int ElevId { get; set; }
        [Required]
        public string Fornavn { get; set; }
        [Required]
        public string Etternavn { get; set; }
        public int Trinn { get; set; }
        public string Klasse { get; set; }
        public string Telefon { get; set; }


        public int SkoleId { get; set; }
        public Skole Skole { get; set; }
    }
}