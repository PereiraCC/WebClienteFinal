using ClienteWebMatricula.Data;
using ClienteWebMatricula.Models;
using ClienteWebMatricula.Models.Crear;
using ClienteWebMatricula.Models.Secundarias;
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
        private Api api = new Api(@"http://localhost/WebApiMatricula/api/");
        private string URL_API = "http://localhost/WebApiMatricula/api/Periodos";

        public IActionResult Periodos()
        {
            List<PeriodosModel> data = ConnectGET();

            return View(data);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            string[] opciones = { "Si", "No" };
            ViewBag.opciones = opciones;
            return View("Crear");
        }

        [HttpPost]
        public ActionResult Crear(Periodos periodo)
        {
            ModelPeriodosPot temp = new ModelPeriodosPot();
            temp.cargarDatosNuevos(periodo);

            string res = api.ConnectPOST(temp.ToJsonString(), "/Periodos");

            if (res.Equals("1"))
            {
                return RedirectToAction("Periodos", "Periodos");
            }

            return View();
        }

        public ActionResult Actualizar(string id, string PropertyName, string value)
        {
            bool status = false;
            string mensaje = "No Modificado";

            List<Periodos> periodos = ActualizarModelo(id, value, PropertyName);
            ModelPeriodosPot per = new ModelPeriodosPot();

            if (periodos != null)
            {
                foreach (Periodos t in periodos)
                {
                    if (t.Numero.Equals(id))
                    {
                        per.Numero = id;
                        per.FechaInicio = t.FechaInicial;
                        per.FechaFinal = t.FechaFinal;
                        if (t.activo.Equals("Si"))
                        {
                            per.activo = true;
                        }
                        else
                        {
                            per.activo = false;
                        }
                        
                    }
                }

                string res = api.ConnectPUT(per.ToJsonString(), "/Periodos", id);

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

        public List<Periodos> ActualizarModelo(string id, string cambio, string p)
        {
            List<Periodos> periodos = new List<Periodos>();
            List<PeriodosModel> datos = ConnectGET();
            List<Periodos> datitos = new List<Periodos>();

            foreach (PeriodosModel t in datos)
            {
                Periodos txt = new Periodos();
                datitos.Add(txt.CargarDatosNuevos(t));
            }

            if (datitos != null)
            {
                foreach (Periodos t in datitos)
                {
                    if (t.Numero.Equals(id))
                    {
                        if (p.Equals("FechaInicial"))
                        {
                            t.FechaInicial = DateTime.Parse(cambio);
                        }
                        else if (p.Equals("FechaFinal"))
                        {
                            t.FechaFinal = DateTime.Parse(cambio);
                        }
                        else if (p.Equals("Activo"))
                        {
                            t.activo = cambio;
                        }
                    }

                    periodos.Add(t);
                }
                return periodos;
            }
            else
            {
                return periodos;
            }
        }

        public ActionResult Eliminar(string id)
        {

            string res = api.ConnectDELETE("/Periodos", id);

            if (res.Equals("1"))
            {
                return RedirectToAction("Periodos", "Periodos");
            }

            return RedirectToAction("Index", "Home");
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
