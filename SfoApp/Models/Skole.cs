using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SfoApp.Models
{
    public class Skole
    {
        [Key]
        public int SkoleId { get; set; }
        public string SkoleNavn { get; set; }
    }
}