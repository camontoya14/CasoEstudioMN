using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CasoEstudio2.Entities;
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

        [HttpGet]
        public ActionResult AlquilarCasas()
        {
            ViewBag.DescripcionCasas = CasasModel.ConsultarDescripciones();
            return View();
        }

        [HttpPost]
        public ActionResult AlquilarCasas(CasaEnt entidad)
        {

            entidad.FechaAlquiler = DateTime.Now;
            var resp = CasasModel.AlquilarCasa(entidad);

            if (resp == "OK")
            {
                return RedirectToAction("ConsultarCasas", "Casas");
            }
            else
            {
                ViewBag.DescripcionCasas = CasasModel.ConsultarDescripciones();
                ViewBag.MensajeUsuario = "No se pudo actualizar la información de su casa";
                return View();
            }
        }


    }
}