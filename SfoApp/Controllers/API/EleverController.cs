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
        public ElevDTO GetElev(int skoleId)  
        {

      
            var elev= _context.Elever.Find(5);
           
            var EleverDto = DTOHelper.Elevmapper(elev);
            return EleverDto;
        }



    }
}
