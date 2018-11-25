using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfoApp.DTO
{
    public class ElevDTO
    {


      
        public string Fornavn { get; set; }
      
        public string Etternavn { get; set; }
        public int Trinn { get; set; }
        public string Klasse { get; set; }
        public string Telefon { get; set; }

        public int SkoleId { get; set; }


    }
}