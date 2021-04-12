using ClienteWebMatricula.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Controllers
{
    public class PeriodosController : Controller
    {
        private string URL_API = "http://localhost/WebApiMatricula/api/Periodos";

        public IActionResult Periodos()
        {
            List<PeriodosModel> data = ConnectGET();

            return View(data);
        }

        public List<PeriodosModel> ConnectGET()
        {
            try
            {
                List<PeriodosModel> lista = null;

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(URL_API);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        var task1 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task1.Result;
                        ModelError error = JsonConvert.DeserializeObject<ModelError>(mens);
                        //lista.Add(error.Exceptionmessage);
                        return lista;

                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        lista = JsonConvert.DeserializeObject<List<PeriodosModel>>(mens);

                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
