using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SfoApp.DTO;
using SfoApp.Models;

namespace SfoApp.ViewModels
{
    public class SFOViewModel
    {
        public Skole Skole { get; set; }
        public List<Skole> Skoler { get; set; }

        public AnsattDto AnsattDto { get; set; }
        public List<AnsattDto> DtoAnsattListe { get; set; }

        public ElevDTO dtoElev { get; set; }
        public List<ElevDTO> dtoElevListe { get; set; }

        public SjekkInnLoggDto SjekkInnLoggDto { get; set; }
    }




}