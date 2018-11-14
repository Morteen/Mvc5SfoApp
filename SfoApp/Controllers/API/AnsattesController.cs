using SfoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SfoApp.DTO;

namespace SfoApp.Controllers.API
{
    public class AnsattesController : ApiController
    {
        private ApplicationDbContext _context;

        public AnsattesController()
        {
            _context = new ApplicationDbContext();
        }



        public IEnumerable<AnsattDto> GetAnsattes()
        {
            List<AnsattDto> ansatte = DTOHelper.AnnsattListToDTOList(_context.Ansatte.ToList());
            return ansatte;
        }




        public AnsattDto GetAnsattes(Ansatt ansatt)
        {
            Ansatt tempAnsatt = _context.Ansatte.Where(a=>a.Username==ansatt.Username&&a.Password==ansatt.Password&&a.SkoleId==ansatt.SkoleId).SingleOrDefault();
            var ansattDto = DTOHelper.MapAnsattToDoDto(tempAnsatt);
            return ansattDto;
        }






        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


    }
}
