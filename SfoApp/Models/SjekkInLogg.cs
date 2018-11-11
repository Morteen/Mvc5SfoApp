using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfoApp.Models
{
    public class SjekkInLogg
    {
        public int Id { get; set; }
        public DateTime SjekkInn { get; set; }
        public DateTime SjekkUt { get; set; }
        public string Info { get; set; }

        public int ElevId { get; set; }
        public List<Elev> Elever { get; set; }

        public int AnsattId { get; set; }
        public List<Ansatt> Ansatt { get; set; }

        public int SkoleId { get; set; }
        public Skole Skole { get; set; }
    }
}