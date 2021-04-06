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
    public class EstudiantesController : Controller
    {
        private string URL_API = "http://localhost/WebApiMatricula/api/Usuarios/Estudiantes";

        public IActionResult Estudiantes()
        {
            List<ModelUsuario> data = ConnectGET();

            return View(data);
        }

        public List<ModelUsuario> ConnectGET()
        {
            try
            {
                List<ModelUsuario> lista = null;

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
                        lista = JsonConvert.DeserializeObject<List<ModelUsuario>>(mens);

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
