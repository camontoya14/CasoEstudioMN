using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CasoEstudio2.Models;

namespace CasoEstudio2.Controllers
{
    public class CasasController : Controller
    {
        // GET: Casas
        CasasModel CasasModel = new CasasModel();

        [HttpGet]
        public ActionResult ConsultarCasas()
        {
            var datos = CasasModel.ConsultarCasas();
            return View(datos);
        }
    }
}