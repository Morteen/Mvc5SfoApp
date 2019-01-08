using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SfoApp.DTO;
using SfoApp.Models;

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
            List<SjekkInnLoggDto> sjekkinne = DTOHelper.toSjekkinnDtoList(_context.SjekkInLogg.Where(s=>s.SkoleId==skoleId&&s.ElevId==elevId).Include(s=>s.Ansatt).ToList());
            return sjekkinne;
        }


        // POST: api/SjekkLoggInns
        [HttpPost]
        public string SjekkLoggInns(int skoleId,int elevId,int AnsattId, string info)
        {
            var date=  DateTime.Now;
            var dto=new SjekkInnLoggDto();
            dto.SkoleId = skoleId;
            dto.AnsattId = AnsattId;
            dto.ElevId = elevId;
            dto.Info = info;
            dto.SjekkInn = date.ToString();



            var sjekkInn = new SjekkInLogg();
            
              
        ;
            if (ModelState.IsValid)
            {
                sjekkInn = DTOHelper.mapInnsjekkDto(dto);
                _context.SjekkInLogg.Add(sjekkInn);
                _context.SaveChanges();
                return "success";
            }

            return "feil";


        }


    }
}
