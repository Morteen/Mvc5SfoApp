using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfoApp.DTO
{
    public class SjekkInnLoggDto
    {
        
       
        public int Id { get; set; }
        public string AnsattNavn { get; set; }
       
        public string SjekkInn { get; set; }
       
        public string SjekkUt { get; set; }
        public string Aar
        {
            get ;
            set ; 
        }
        public string Dato{ get; set; }

        public string Info { get; set; }

        public int AnsattId { get; set; }

        public int ElevId { get; set; }
     
        public int SkoleId { get; set; }


      

    }
}