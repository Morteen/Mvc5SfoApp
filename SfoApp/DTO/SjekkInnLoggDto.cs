using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfoApp.DTO
{
    public class SjekkInnLoggDto
    {

       
        public int Id { get; set; }

       
        public DateTime SjekkInn { get; set; }
       
        public DateTime SjekkUt { get; set; }

        public string Info { get; set; }

        public int ElevId { get; set; }
     
        public int SkoleId { get; set; }
      

    }
}