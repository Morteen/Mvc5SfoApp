using SfoApp.DTO;
using SfoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SfoApp.Controllers.API
{
    public class EleverController : ApiController
    {
        private ApplicationDbContext _context;

        public EleverController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Elever
        public IEnumerable<ElevDTO> GetElever()
        {
            
            return null;
        }

        // GET: api/Elever/1
        public IEnumerable<ElevDTO> GetElev(int skoleId)
        {
           

            return DTOHelper.ElevListMapper(_context.Elever.Where(e => e.SkoleId == skoleId).ToList());
        }



    }
}
