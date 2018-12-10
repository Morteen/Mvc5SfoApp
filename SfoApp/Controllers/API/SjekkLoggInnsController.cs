using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SfoApp.DTO;

namespace SfoApp.Controllers.API
{
    public class SjekkLoggInnsController : ApiController
    {

        private Models.ApplicationDbContext _context;
        public SjekkLoggInnsController()
        {
           _context = new Models.ApplicationDbContext();
        }



        public IEnumerable<SjekkInnLoggDto> GetSjekkInns()
        {
            List<SjekkInnLoggDto> sjekkinne = DTOHelper.toSjekkinnDtoList(_context.SjekkInLogg.ToList());
            return sjekkinne;
        }

        public IEnumerable<SjekkInnLoggDto> GetSjekk(int skoleId,int elevId)
        {
            List<SjekkInnLoggDto> sjekkinne = DTOHelper.toSjekkinnDtoList(_context.SjekkInLogg.Where(s=>s.SkoleId==skoleId&&s.ElevId==elevId).ToList());
            return sjekkinne;
        }

    }
}
