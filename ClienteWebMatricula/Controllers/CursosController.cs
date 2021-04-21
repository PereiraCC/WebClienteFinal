using ClienteWebMatricula.Data;
using ClienteWebMatricula.Models;
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
    public class CursosController : Controller
    {
        private Api api = new Api(@"http://localhost/WebApiMatricula/api/");
        private string URL_API = "http://localhost/WebApiMatricula/api/Cursos";
        private string URL_Carreras = "http://localhost/WebApiMatricula/api/Carreras";

        public IActionResult Cursos()
        {
            List<ModelCursos> data = ConnectGET();
            List<Cursos> datitos = new List<Cursos>();
            foreach (ModelCursos t in data)
            {
                Cursos txt = new Cursos();
                datitos.Add(txt.CargarDatosNuevos(t));
            }

            return View(datitos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            Cursos curso = new Cursos();
            curso.Carreras = cargarCarreras();
            return View(curso);
        }

        [HttpPost]
        public ActionResult Crear(Cursos cursos)
        {
            ModelCursos temp = new ModelCursos();
            temp.cargarDatosNuevos(cursos);

            string res = api.ConnectPOST(temp.ToJsonString(), "/Cursos");

            if (res.Equals("1"))
            {
                return RedirectToAction("Cursos", "Cursos");
            }

            return View();
        }

        public ActionResult Actualizar(string id, string PropertyName, string value)
        {
            bool status = false;
            string mensaje = "No Modificado";

            List<Cursos> cursos = ActualizarModelo(id, value, PropertyName);
            ModelCursos cur = new ModelCursos();

            if (cursos != null)
            {
                foreach (Cursos t in cursos)
                {
                    if (t.Codigo == Int32.Parse(id))
                    {
                        cur.Codigo = Int32.Parse(id);
                        cur.Nombre = t.Nombre;
                        cur.NombreCarrera = t.NombreCarrera;
                    }
                }

                string res = api.ConnectPUT(cur.ToJsonString(), "/Cursos", id);

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

        public List<Cursos> ActualizarModelo(string id, string cambio, string p)
        {
            List<Cursos> cursos = new List<Cursos>();
            List<ModelCursos> datos = ConnectGET();
            List<Cursos> datitos = new List<Cursos>();

            foreach (ModelCursos t in datos)
            {
                Cursos txt = new Cursos();
                datitos.Add(txt.CargarDatosNuevos(t));
            }

            if (datitos != null)
            {
                foreach (Cursos t in datitos)
                {
                    if (t.Codigo == Int32.Parse(id))
                    {
                        if (p.Equals("Nombre"))
                        {
                            t.Nombre = cambio;
                        }
                        else if (p.Equals("NombreCarrera"))
                        {
                            t.NombreCarrera = cambio;
                        }
                    }

                    cursos.Add(t);
                }
                return cursos;
            }
            else
            {
                return cursos;
            }
        }

        public ActionResult Eliminar(string id)
        {

            string res = api.ConnectDELETE("/Cursos", id);

            if (res.Equals("1"))
            {
                return RedirectToAction("Cursos", "Cursos");
            }

            return RedirectToAction("Index", "Home");
        }

        public List<ModelCursos> ConnectGET()
        {
            try
            {
                List<ModelCursos> lista = null;

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
                        lista = JsonConvert.DeserializeObject<List<ModelCursos>>(mens);

                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> cargarCarreras()
        {

            try
            {
                List<string> carreras = new List<string>();
                List<ModelCarreras> lista = null;

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(URL_Carreras);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        lista = JsonConvert.DeserializeObject<List<ModelCarreras>>(mens);
                    }

                    foreach (ModelCarreras car in lista)
                    {
                        carreras.Add(car.Nombre);
                    }

                    return carreras;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
