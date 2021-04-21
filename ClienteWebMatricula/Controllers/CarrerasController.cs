using ClienteWebMatricula.Data;
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
    public class CarrerasController : Controller
    {
        private Api api = new Api(@"http://localhost/WebApiMatricula/api/");
        private string URL_API = "http://localhost/WebApiMatricula/api/Carreras";

        public ActionResult Carreras()
        {
            List<ModelCarreras> data = ConnectGET();

            return View(data);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ModelCarreras carrera)
        {

            string res = api.ConnectPOST(carrera.ToJsonString(), "/Carreras");

            if (res.Equals("1"))
            {
                return RedirectToAction("Carreras", "Carreras");
            }

            return View();
        }

        public ActionResult Actualizar(string id, string PropertyName, string value)
        {
            bool status = false;
            string mensaje = "No Modificado";

            List<ModelCarreras> carreras = ActualizarModelo(id, value, PropertyName);
            ModelCarreras car = new ModelCarreras();

            if (carreras != null)
            {
                foreach (ModelCarreras t in carreras)
                {
                    if (t.Codigo.Equals(id))
                    {
                        car = t;
                    }
                }

                string res = api.ConnectPUT(car.ToJsonString(), "/Carreras", id);

                if (res.Equals("1"))
                {
                    status = true;
                    mensaje = "Valor modificado";
                }

                return Json(new { value = value, status = status, mensaje = mensaje });

            }
            else
            {
                return Json(new { value = value, status = status, mensaje = mensaje });
            }

        }

        public List<ModelCarreras> ActualizarModelo(string id, string cambio, string p)
        {
            List<ModelCarreras> carreras = new List<ModelCarreras>();
            List<ModelCarreras> datos = ConnectGET();

            if (datos != null)
            {
                foreach (ModelCarreras c in datos)
                {
                    if (c.Codigo.Equals(id))
                    {
                        if (p.Equals("Nombre"))
                        {
                            c.Nombre = cambio;
                        }
                    }

                    carreras.Add(c);
                }
                return carreras;
            }
            else
            {
                return carreras;
            }
        }

        public ActionResult Eliminar(string id)
        {

            string res = api.ConnectDELETE("/Carreras", id);

            if (res.Equals("1"))
            {
                return RedirectToAction("Carreras", "Carreras");
            }

            return RedirectToAction("Index", "Home");
        }

        public List<ModelCarreras> ConnectGET()
        {
            try
            {
                List<ModelCarreras> lista = null;

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
                        lista = JsonConvert.DeserializeObject<List<ModelCarreras>>(mens);

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
