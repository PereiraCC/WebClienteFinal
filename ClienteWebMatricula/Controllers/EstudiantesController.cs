using ClienteWebMatricula.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClienteWebMatricula.Models.Secundarias;
using ClienteWebMatricula.Models.Modificar;
using ClienteWebMatricula.Data;
using ClienteWebMatricula.Models.Crear;

namespace ClienteWebMatricula.Controllers
{
    public class EstudiantesController : Controller
    {
        private Api api = new Api(@"http://localhost/WebApiMatricula/api/");
        private string URL_API = "http://localhost/WebApiMatricula/api/Usuarios/Estudiantes";

        public ActionResult Estudiantes()
        {
            List<ModelUsuario> datos = ConnectGET();
            List<Estudiante> datitos = new List<Estudiante>();
            foreach (ModelUsuario t in datos)
            {
                Estudiante txt = new Estudiante();
                datitos.Add(txt.CargarDatosNuevos(t));
            }
            return View("Estudiantes", datitos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            Estudiante estudiante = new Estudiante();
            estudiante.tiposIdentificacion = cargarTiposUsuario();
            ViewBag.error = null;
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Crear(Estudiante estudiante)
        {
            ModelUsuarioPos temp = new ModelUsuarioPos();
            temp.cargarDatosNuevos(estudiante);

            string res = api.ConnectPOST(temp.ToJsonString(), "/Usuarios");

            if (res.Equals("1"))
            {
                return RedirectToAction("Estudiantes", "Estudiantes");
            }
            else
            {
                Estudiante es = new Estudiante();
                es.tiposIdentificacion = cargarTiposUsuario();
                ViewBag.error = res;
                return View(es);
            }

            
        }

        public ActionResult Eliminar(string id)
        {

            string res = api.ConnectDELETE("/Usuarios", id);

            if (res.Equals("1"))
            {
                return RedirectToAction("Estudiantes", "Estudiantes");
            }
            else
            {
                return RedirectToAction("Estudiantes", "Estudiantes");
            }
           
        }

        public ActionResult Emails(string id)
        {
            List<ModelUsuario> data = ConnectGET();
            List<ModelEmails> emails = ObtenerEmails(data, id);
            return View(emails);
        }

        public ActionResult Telefonos(string id)
        {
            List<ModelUsuario> data = ConnectGET();
            List<ModelTelefonos> tels = ObtenerTelefonos(data, id);
            return View(tels);
        }

        public ActionResult Editar(string id)
        {
            ModelUsuario data = ObtenerUnUsuario(id);
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
                        System.Web.Mvc.ModelError error = JsonConvert.DeserializeObject<System.Web.Mvc.ModelError>(mens);
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

        public List<string> cargarTiposUsuario()
        {
            try
            {
                List<string> tiposUsuario = new List<string>();
                string data = "Cédula de Identidad,DIMEX,Cédula de Residencia,Pasaporte";

                string[] tipos = data.Split(',');

                foreach(string temp in tipos)
                {
                    tiposUsuario.Add(temp);
                }
                return tiposUsuario;
            }
            catch(Exception ex)
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

        public ModelUsuario ObtenerUnUsuario(string id)
        {
            try
            {
                ModelUsuario usuario = null;

                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {
                        return await client.GetAsync(URL_API + "/UnEstudiante?id=" + id);
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
                        System.Web.Mvc.ModelError error = JsonConvert.DeserializeObject<System.Web.Mvc.ModelError>(mens);
                        return usuario;

                    }
                    else if (message.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        return usuario;

                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        usuario = JsonConvert.DeserializeObject<ModelUsuario>(mens);

                    }
                    return usuario; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Actualizar(string id, string PropertyName, string value)
        {
            bool status = false;
            string mensaje = "No Modificado";

            List<Estudiante> estudiante = ActualizarModelo(id, value, PropertyName);
            Estudiante est = new Estudiante();

            if (estudiante != null)
            {
                foreach (Estudiante t in estudiante)
                {
                    if (t.NumeroIdentificacion.Equals(id))
                    {
                        est.NumeroIdentificacion = id;
                        est.nombre = t.nombre;
                        est.Apellidos = t.Apellidos;
                        est.fechanacimiento = t.fechanacimiento;
                        est.Telefonos = t.Telefonos;
                        est.emails = t.emails;
                        est.idtipoIdentificacion = t.idtipoIdentificacion;
                        est.idtipoUsuario = t.idtipoUsuario;
                    }
                }

                ModelUsuarioPut usu = new ModelUsuarioPut();
                usu.cargarDatosNuevos(est);
                string res = api.ConnectPUT(usu.ToJsonString(), "/Usuarios", id);

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

        public List<Estudiante> ActualizarModelo(string id, string cambio, string p)
        {
            List<Estudiante> estudiante = new List<Estudiante>();
            List<ModelUsuario> datos = ConnectGET();
            List<Estudiante> datitos = new List<Estudiante>();
            foreach (ModelUsuario t in datos)
            {
                Estudiante txt = new Estudiante();
                datitos.Add(txt.CargarDatosNuevos(t));
            }
            if (datitos != null)
            {
                foreach (Estudiante t in datitos)
                {
                    if (t.NumeroIdentificacion.Equals(id))
                    {
                        if (p.Equals("Nombre"))
                        {
                            t.nombre = cambio;
                        }
                        else if (p.Equals("Apellidos"))
                        {
                            t.Apellidos = cambio;
                        }
                        else if (p.Equals("Telefonos"))
                        {
                            t.Telefonos = cambio;
                        }
                        else if (p.Equals("emails"))
                        {
                            t.emails = cambio;
                        }
                        else if (p.Equals("fechanacimiento"))
                        {
                            t.fechanacimiento = DateTime.Parse(cambio);
                        }
                    }

                    estudiante.Add(t);
                }
                return estudiante;

            }
            else
            {
                return estudiante;
            }


        }
    }
}
