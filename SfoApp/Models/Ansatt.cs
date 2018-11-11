using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SfoApp.Models
{
    public class Ansatt
    {
        public int AnsattId { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
    }
}