using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using CasoEstudio2.Entities;


namespace CasoEstudio2.Models
{
    public class CasasModel
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public List<CasaEnt> ConsultarCasas()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "ConsultarCasas";
                var res = client.GetAsync(url).Result;

                if (res.IsSuccessStatusCode)
                {
                    var casas = res.Content.ReadFromJsonAsync<List<CasaEnt>>().Result;

                    foreach (var casa in casas)
                    {
                        if (casa.UsuarioAlquiler == null)
                        {
                            casa.UsuarioAlquiler = "Null";
                        }

                        else if (casa.FechaAlquiler == null)
                        {
                            casa.FechaAlquiler = null;
                        }

                    }

                    return casas;
                }
                else
                {
                    throw new System.Exception($"No se puedo obtener la data. error: {res.StatusCode}");
                }
            }
        }

        public string AlquilarCasa(CasaEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "AlquilarCasa";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PutAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public List<SelectListItem> ConsultarDescripciones()
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ConsultarDescripciones";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }
    }
}