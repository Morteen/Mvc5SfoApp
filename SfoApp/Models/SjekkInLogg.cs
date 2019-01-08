using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfoApp.Models
{
    public class SjekkInLogg
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Sjekk inn tidspunkt")]
        public string SjekkInn { get; set; }
        [Display(Name = "Sjekk ut tidspunkt")]
        public string SjekkUt { get; set; }
        
        public string Info { get; set; }

        public int ElevId { get; set; }
        public virtual Elev Elev { get; set; }

        public int AnsattId { get; set; }
        public virtual Ansatt Ansatt { get; set; }

        public int SkoleId { get; set; }
        public virtual Skole Skole { get; set; }
    }
}