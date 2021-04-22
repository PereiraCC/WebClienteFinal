using ClienteWebMatricula.Data;
using ClienteWebMatricula.Models;
using ClienteWebMatricula.Models.Secundarias;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClienteWebMatricula.Controllers
{
    public class GruposController : Controller
    {
        private Api api = new Api(@"http://localhost/WebApiMatricula/api/");
        private string URL_API = "http://localhost/WebApiMatricula/api/Grupos";

        public IActionResult Grupos()
        {
            List<GruposModel> data = ConnectGET();
            List<Grupos> datitos = new List<Grupos>();
            foreach (GruposModel t in data)
            {
                Grupos txt = new Grupos();
                datitos.Add(txt.CargarDatosNuevos(t));
            }
            return View(datitos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.profesores = obtenerNombreProfesores();
            ViewBag.cursos = obtenerNombreCursos();
            ViewBag.horarios = obtenerHorarios();
            ViewBag.periodos = obtenerPeriodos();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Grupos grupo)
        {
            GruposModel temp = new GruposModel();
            temp.cargarDatosNuevos(grupo);

            string res = api.ConnectPOST(temp.ToJsonString(), "/Grupos");

            if (res.Equals("1"))
            {
                return RedirectToAction("Grupos", "Grupos");
            }

            return View();
        }

        public ActionResult Actualizar(string id, string PropertyName, string value)
        {
            bool status = false;
            string mensaje = "No Modificado";

            List<Grupos> grupos = ActualizarModelo(id, value, PropertyName);
            GruposModel cur = new GruposModel();

            if (grupos != null)
            {
                foreach (Grupos t in grupos)
                {
                    if (t.Numero.Equals(id))
                    {
                        cur.Numero = id;
                        cur.codigoProfesor = t.codigoProfesor;
                        cur.nombreCurso = t.nombreCurso;
                        cur.codigoHorario = t.codigoHorario;
                        cur.codigoPeriodo = t.codigoPeriodo;
                    }
                }

                string res = api.ConnectPUT(cur.ToJsonString(), "/Grupos", id);

                if (res.Equals("1"))
                {
                    status = true;
                    mensaje = "Valor modificado";
                }

                if (PropertyName.Equals("NombreProfesor"))
                {
                    return Json(new { value = obtenerUnNombreProfesor(value), status = status, mensaje = mensaje });
                }
                else if (PropertyName.Equals("nombreCurso"))
                {
                    return Json(new { value = obtenerUnNombreCursos(value), status = status, mensaje = mensaje });
                }
                else if (PropertyName.Equals("Horario"))
                {
                    return Json(new { value = obtenerUnHorario(value), status = status, mensaje = mensaje });
                }
                else if (PropertyName.Equals("Periodo"))
                {
                    return Json(new { value = obtenerUnPeriodo(value), status = status, mensaje = mensaje });
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

        public List<Grupos> ActualizarModelo(string id, string cambio, string p)
        {
            List<Grupos> grupos = new List<Grupos>();
            List<GruposModel> datos = ConnectGET();
            List<Grupos> datitos = new List<Grupos>();

            foreach (GruposModel t in datos)
            {
                Grupos txt = new Grupos();
                datitos.Add(txt.CargarDatosNuevos(t));
            }

            if (datitos != null)
            {
                foreach (Grupos t in datitos)
                {
                    if (t.Numero.Equals(id))
                    {
                        if (p.Equals("NombreProfesor"))
                        {
                            t.NombreProfesor = obtenerUnNombreProfesor(cambio);
                            t.codigoProfesor = cambio;
                        }
                        else if (p.Equals("nombreCurso"))
                        {
                            t.nombreCurso = obtenerUnNombreCursos(cambio);
                        }
                        else if (p.Equals("Horario"))
                        {
                            t.Horario = obtenerUnHorario(cambio);
                            t.codigoHorario = cambio;
                        }
                        else if (p.Equals("Periodo"))
                        {
                            t.Periodo = obtenerUnPeriodo(cambio);
                            t.codigoPeriodo = cambio;
                        }
                    }

                    grupos.Add(t);
                }
                return grupos;
            }
            else
            {
                return grupos;
            }
        }

        public ActionResult Eliminar(string id)
        {

            string res = api.ConnectDELETE("/Grupos", id);

            if (res.Equals("1"))
            {
                return RedirectToAction("Grupos", "Grupos");
            }

            return RedirectToAction("Index", "Home");
        }

        public List<GruposModel> ConnectGET()
        {
            try
            {
                List<GruposModel> lista = null;

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
                        lista = JsonConvert.DeserializeObject<List<GruposModel>>(mens);

                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<string> obtenerNombreProfesores()
        {
            try
            {
                List<string> profes = new List<string>();
                ProfesoresController controller = new ProfesoresController();
                List<ModelUsuario> profesores = controller.ConnectGET();

                foreach (ModelUsuario temp in profesores)
                {
                    profes.Add(temp.Nombre + " " + temp.Apellidos);
                }

                return profes;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerNombreProfesoresModificar()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                ProfesoresController controller = new ProfesoresController();
                List<ModelUsuario> profesores = controller.ConnectGET();

                foreach (ModelUsuario item in profesores)
                {
                    string nombreC = item.Nombre + " " + item.Apellidos;
                    sb.Append(string.Format("'{0}':'{1}',", item.NumeroIdentificacion, nombreC));
                }
                

                return "{" + sb.ToString() + "}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string obtenerUnNombreProfesor(string id)
        {
            try
            {
                ProfesoresController controller = new ProfesoresController();
                List<ModelUsuario> profesores = controller.ConnectGET();

                foreach (ModelUsuario item in profesores)
                {
                    if (item.NumeroIdentificacion.Equals(id))
                    {
                        return item.Nombre + " " + item.Apellidos;
                    }
                }

                return "Sin Nombre";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<string> obtenerNombreCursos()
        {
            try
            {
                List<string> cur = new List<string>();
                CursosController controller = new CursosController();
                List<ModelCursos> cursos = controller.ConnectGET();

                foreach (ModelCursos temp in cursos)
                {
                    cur.Add(temp.Nombre);
                }

                return cur;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerNombreCursosModificar()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                CursosController controller = new CursosController();
                List<ModelCursos> cursos = controller.ConnectGET();

                foreach (ModelCursos item in cursos)
                {
                    sb.Append(string.Format("'{0}':'{1}',", item.Codigo, item.Nombre));
                }


                return "{" + sb.ToString() + "}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string obtenerUnNombreCursos(string id)
        {
            try
            {
                CursosController controller = new CursosController();
                List<ModelCursos> cursos = controller.ConnectGET();

                foreach (ModelCursos item in cursos)
                {
                    if(item.Codigo == Int32.Parse(id))
                    {
                        return item.Nombre;
                    }
                }


                return "Sin Nombre";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<string> obtenerHorarios()
        {
            try
            {
                List<string> hor = new List<string>();
                HorariosController controller = new HorariosController();
                List<HorarioModel> horarios = controller.ConnectGET();

                foreach (HorarioModel temp in horarios)
                {
                    hor.Add(temp.Dia + " " + temp.HoraInicio.ToString() + " - " + temp.HoraFinal.ToString());
                }

                return hor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerHorariosModificar()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                HorariosController controller = new HorariosController();
                List<HorarioModel> horarios = controller.ConnectGET();

                foreach (HorarioModel item in horarios)
                {
                    string horario = item.Dia + " " + item.HoraInicio.ToString() + " - " + item.HoraFinal.ToString();
                    sb.Append(string.Format("'{0}':'{1}',", item.Codigo, horario));
                }


                return "{" + sb.ToString() + "}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string obtenerUnHorario(string id)
        {
            try
            {
                HorariosController controller = new HorariosController();
                List<HorarioModel> horarios = controller.ConnectGET();

                foreach (HorarioModel item in horarios)
                {
                    if (item.Codigo == Int32.Parse(id))
                    {
                        return item.Dia + " " + item.HoraInicio.ToString() + " - " + item.HoraFinal.ToString();
                    }
                }

                return "Sin Nombre";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<string> obtenerPeriodos()
        {
            try
            {
                List<string> per = new List<string>();
                PeriodosController controller = new PeriodosController();
                List<PeriodosModel> periodos = controller.ConnectGET();

                foreach (PeriodosModel temp in periodos)
                {
                    per.Add(temp.FechaInicial.ToShortDateString() + " - " + temp.FechaFinal.ToShortDateString());
                }

                return per;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string obtenerPeriodosModificar()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                PeriodosController controller = new PeriodosController();
                List<PeriodosModel> periodos = controller.ConnectGET();

                foreach (PeriodosModel item in periodos)
                {
                    string periodo = item.FechaInicial.ToShortDateString() + " - " + item.FechaFinal.ToShortDateString();
                    sb.Append(string.Format("'{0}':'{1}',", item.Numero, periodo));
                }

                return "{" + sb.ToString() + "}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string obtenerUnPeriodo(string id)
        {
            try
            {
                PeriodosController controller = new PeriodosController();
                List<PeriodosModel> periodos = controller.ConnectGET();

                foreach (PeriodosModel item in periodos)
                {
                    if (item.Numero.Equals(id))
                    {
                        return item.FechaInicial.ToShortDateString() + " - " + item.FechaFinal.ToShortDateString();
                    }
                }

                return "Sin Nombre";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
