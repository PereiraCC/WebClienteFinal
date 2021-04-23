using ClienteWebMatricula.Data;
using ClienteWebMatricula.Models;
using ClienteWebMatricula.Models.Crear;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Controllers
{
    public class HorariosController : Controller
    {
        private Api api = new Api(@"http://localhost/WebApiMatricula/api/");
        private string URL_API = "http://localhost/WebApiMatricula/api/Horarios";

        public IActionResult Horarios()
        {
            List<HorarioModel> data = ConnectGET();

            return View(data);
        }

        [HttpGet]
        public ActionResult Crear()
        {         
            ViewBag.opciones = cargarDiasModificar();
            ViewBag.error = null;
            return View("Crear");
        }

        [HttpPost]
        public ActionResult Crear(HorarioModel horario)
        {
            ModelHorarioPot temp = new ModelHorarioPot();
            temp.cargarDatosNuevos(horario);

            string res = api.ConnectPOST(temp.ToJsonString(), "/Horarios");

            if (res.Equals("1"))
            {
                return RedirectToAction("Horarios", "Horarios");
            }
            else
            {
                ViewBag.opciones = cargarDiasModificar();
                ViewBag.error = res;
                return View();
            }

        }

        public ActionResult Actualizar(string id, string PropertyName, string value)
        {
            bool status = false;
            string mensaje = "No Modificado";

            List<HorarioModel> horarios = ActualizarModelo(id, value, PropertyName);
            ModelHorarioPot hor = new ModelHorarioPot();

            if (horarios != null)
            {
                foreach (HorarioModel t in horarios)
                {
                    if (t.Codigo == Int32.Parse(id))
                    {
                        hor.Codigo = Int32.Parse(id);
                        hor.dia = t.Dia;
                        hor.HoraInicio = t.HoraInicio;
                        hor.HoraFinal = t.HoraFinal;
                    }
                }

                string res = api.ConnectPUT(hor.ToJsonString(), "/Horarios", id);

                if (res.Equals("1"))
                {
                    status = true;
                    mensaje = "Valor modificado";
                }

                if (PropertyName.Equals("Dia"))
                {
                    if (value.Equals("0"))
                    {
                        return Json(new { value = "Lunes", status = status, mensaje = mensaje });
                    }
                    else if (value.Equals("1"))
                    {
                        return Json(new { value = "Martes", status = status, mensaje = mensaje });
                    }
                    else if (value.Equals("2"))
                    {
                        return Json(new { value = "Miercoles", status = status, mensaje = mensaje });
                    }
                    else if (value.Equals("3"))
                    {
                        return Json(new { value = "Jueves", status = status, mensaje = mensaje });  
                    }
                    else if (value.Equals("4"))
                    {
                        return Json(new { value = "Viernes", status = status, mensaje = mensaje });
                    }
                    else
                    {
                        return Json(new { value = "Sabado", status = status, mensaje = mensaje });
                    }
                    
                }
                else
                {
                    return Json(new { value = value, status = status, mensaje = mensaje });
                }
            }
            else
            {
                return Json(new { value = value, status = status, mensaje = mensaje });
            }

        }

        public List<HorarioModel> ActualizarModelo(string id, string cambio, string p)
        {
            List<HorarioModel> periodos = new List<HorarioModel>();
            List<HorarioModel> datos = ConnectGET();

            if (datos != null)
            {
                foreach (HorarioModel t in datos)
                {
                    if (t.Codigo == Int32.Parse(id))
                    {
                        if (p.Equals("Dia"))
                        {
                            if (cambio.Equals("0"))
                            {
                                t.Dia = "Lunes";
                            }
                            else if (cambio.Equals("1"))
                            {
                                t.Dia = "Martes";
                            }
                            else if (cambio.Equals("2"))
                            {
                                t.Dia = "Miercoles";
                            }
                            else if (cambio.Equals("3"))
                            {
                                t.Dia = "Jueves";
                            }
                            else if (cambio.Equals("4"))
                            {
                                t.Dia = "Viernes";
                            }
                            else if (cambio.Equals("5"))
                            {
                                t.Dia = "Sabado";
                            }

                        }
                        else if (p.Equals("HoraInicio"))
                        {
                            t.HoraInicio = TimeSpan.Parse(cambio);
                        }
                        else if (p.Equals("HoraFinal"))
                        {
                            t.HoraFinal = TimeSpan.Parse(cambio);
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

            string res = api.ConnectDELETE("/Horarios", id);

            if (res.Equals("1"))
            {
                return RedirectToAction("Horarios", "Horarios");
            }

            return RedirectToAction("Index", "Home");
        }

        public List<HorarioModel> ConnectGET()
        {
            try
            {
                List<HorarioModel> lista = null;

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
                        lista = JsonConvert.DeserializeObject<List<HorarioModel>>(mens);

                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string[] cargarDiasModificar()
        {
            try
            {
                string[] dias = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" };
                return dias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
