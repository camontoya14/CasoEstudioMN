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

        [HttpGet]
        [Route("ConsultaCasa")]
        public CasasSistema ConsultaCasa(string q)
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.CasasSistema
                                 where x.DescripcionCasa == q
                                 select x).FirstOrDefault();

                    return datos;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultarDescripciones")]
        public List<System.Web.Mvc.SelectListItem> ConsultarDescripciones()
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    var datos = (from x in context.CasasSistema
                                 select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.IdCasa.ToString(), Text = item.DescripcionCasa });
                    }

                    return respuesta;
                }
            }
            catch (Exception)
            {
                return new List<System.Web.Mvc.SelectListItem>();
            }
        }

        [HttpPut]
        [Route("AlquilarCasa")]
        public string AlquilarCasa(CasasEnt entidad)
        {
            try
            {
                using (var context = new CasoEstudioMNEntities())
                {
                    var datos = (from x in context.CasasSistema
                                 where x.IdCasa == entidad.IdCasa
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        datos.DescripcionCasa = entidad.DescripcionCasa;
                        datos.PrecioCasa = entidad.PrecioCasa;
                        datos.UsuarioAlquiler = entidad.UsuarioAlquiler;
                        datos.FechaAlquiler = entidad.FechaAlquiler;
                        context.SaveChanges();
                    }

                    return "OK";
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
