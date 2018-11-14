using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SfoApp.DTO
{
    public class AnsattDto
    {

        public int AnsattId { get; set; }
      
        public string Fornavn { get; set; }
      
        public string Etternavn { get; set; }
      
        public string Username { get; set; }

        public string Password { get; set; }

        public int SkoleId { get; set; }



    }
}