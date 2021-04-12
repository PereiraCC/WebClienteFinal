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
    public class ProfesoresController : Controller
    {

        private string URL_API = "http://localhost/WebApiMatricula/api/Usuarios/Profesores";

        public IActionResult Profesores()
        {
            List<ModelUsuario> data = ConnectGET();

            return View(data);
        }

        public IActionResult Emails(string id)
        {
            List<ModelUsuario> data = ConnectGET();
            List<ModelEmails> emails = ObtenerEmails(data, id);
            return View(emails);
        }

        public IActionResult Telefonos(string id)
        {
            List<ModelUsuario> data = ConnectGET();
            List<ModelTelefonos> tels = ObtenerTelefonos(data, id);
            return View(tels);
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

        public List<ModelTelefonos> ObtenerTelefonos(List<ModelUsuario> data, string id)
        {
            try
            {
                List<ModelTelefonos> lista = new List<ModelTelefonos>();
                foreach (ModelUsuario user in data)
                {
                    if (user.NumeroIdentificacion.Equals(id))
                    {
                        lista = user.Telefonos;
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModelEmails> ObtenerEmails(List<ModelUsuario> data, string id)
        {
            try
            {
                List<ModelEmails> lista = new List<ModelEmails>();
                foreach (ModelUsuario user in data)
                {
                    if (user.NumeroIdentificacion.Equals(id))
                    {
                        lista = user.Emails;
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
