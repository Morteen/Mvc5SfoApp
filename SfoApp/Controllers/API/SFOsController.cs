using SfoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SfoApp.ViewModels;
using SfoApp.DTO;

namespace SfoApp.Controllers.API
{
    public class SFOsController : ApiController
    {

        //Skaffer database tilgang 
        private Models.ApplicationDbContext _context;

        public SFOsController()
        {
            _context = new ApplicationDbContext();
        }



        // Finner hele med kontakt personer
        //Get /api/SFOs

        public SFOViewModel GetSFOs()
        {

            SFOViewModel SfoModel= new SFOViewModel();
            var elever = _context.Elever.ToList();
            var ansatte = _context.Ansatte.ToList();
            var Skoler = _context.Skoler.ToList();

            SfoModel.dtoElevListe = DTOHelper.ElevListMapper(elever);
            SfoModel.DtoAnsattListe = DTOHelper.AnnsattListToDTOList(ansatte);
            SfoModel.Skoler = Skoler;

            return SfoModel;
        }
        




    }
}
