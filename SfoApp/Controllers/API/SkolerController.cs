using SfoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SfoApp.Controllers.API
{
    public class SkolerController : ApiController
    {

        //Skaffer database tilgang 
        private Models.ApplicationDbContext _context;

        public SkolerController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Skole> GetSkoler()
        {
            return _context.Skoler.ToList();
        }
        public Skole GetSkole(int id)
        {
            return _context.Skoler.Where(s => s.SkoleId == id).SingleOrDefault();
        }
    }
}
