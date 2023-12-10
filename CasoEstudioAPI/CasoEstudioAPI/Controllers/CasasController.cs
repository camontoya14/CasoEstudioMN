using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using CasoEstudioAPI.Entities;

namespace CasoEstudioAPI.Controllers
{
    public class CasasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarCasas")]
        public List<CasasSistema> ConsultarCasas()
        {
            using (var context = new CasoEstudioMNEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return context.CasasSistema.ToList();
            }
        }
    }
}
