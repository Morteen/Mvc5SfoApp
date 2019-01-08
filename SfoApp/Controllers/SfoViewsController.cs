using SfoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SfoApp.DTO;
using SfoApp.ViewModels;

namespace SfoApp.Controllers
{
    public class SfoViewsController : Controller
    {
        private ApplicationDbContext _context;
        public SfoViewsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: SfoViews
        public ActionResult Index()
        {
            SFOViewModel SFO = new SFOViewModel();

            SFO.dtoElevListe = DTOHelper.ElevListMapper(_context.Elever.ToList());
            SFO.Skoler = _context.Skoler.ToList();
            SFO.DtoAnsattListe = DTOHelper.AnnsattListToDTOList(_context.Ansatte.ToList());
            return View();
        }




        public ActionResult LoginAnsatt(string username,string password,int skoleId)
        {
           
            if (ModelState.IsValid)
            {
                var ansatt = _context.Ansatte
                    .Where(a => a.Username == username && a.Password == password && a.SkoleId == skoleId)
                    .SingleOrDefault();
                AnsattDto dtoAnsatt = DTOHelper.MapAnsattToDoDto(ansatt);
                return Json(dtoAnsatt, JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GetElever(int skoleId)
        {
            var dtoElevListe = DTOHelper.ElevListMapper(_context.Elever.Where(e=>e.SkoleId==skoleId).ToList());


            if (dtoElevListe == null) { 

            return Json(dtoElevListe, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }


        }

        
        public ActionResult postOppmote(int skoleId, int elevId, int AnsattId, string info)
            
        {
            var date = DateTime.Now;
            var dto = new SjekkInnLoggDto();
            dto.SkoleId = skoleId;
            dto.AnsattId = AnsattId;
            dto.ElevId = elevId;
            dto.Info = info;
            dto.SjekkInn = date.ToString();



            var sjekkInn = new SjekkInLogg();



            if (ModelState.IsValid)
            {
                sjekkInn = DTOHelper.mapInnsjekkDto(dto);
                _context.SjekkInLogg.Add(sjekkInn);
                _context.SaveChanges();
                return Json(elevId, JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }



    }
}