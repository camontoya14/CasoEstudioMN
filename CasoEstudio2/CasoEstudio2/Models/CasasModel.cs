using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
                return res.Content.ReadFromJsonAsync<List<CasaEnt>>().Result;
            }
        }

        public string ActualizarSaldo(long Id_Compra, decimal Monto)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "ActualizarSaldo";
                var data = new { Id_Compra, Monto };
                var content = JsonContent.Create(data);
                var response = client.PostAsync(url, content).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}